const Article = require('mongoose').model('Article');

module.exports = {
    createGet:(req,res) => {
        res.render('article/create');
    },

    createPost:(req, res)=>{
        let articleDetails = req.body;

        let errMsg = '';

        if(!req.isAuthenticated())
            errMsg = 'You should be logged in to make articles!';
        else if (!articleDetails.title)
            errMsg = 'Invalid title!';
        else if(!articleDetails.content)
            errMsg = 'Invalid content!';

        if(errMsg){
            res.render('article/create', {error: errMsg});
            return;
        }

        articleDetails.author = req.user.id;
        Article.create(articleDetails).then(article => {
            req.user.articles.push(article.id);
            req.user.save(err => {
                err?
                    res.redirect('/',{error:err.message}):
                    res.redirect('/');
            });
        })
    },

    details: (req, res) => {
      let id = req.params.id;

      Article.findById(id).populate('author').then(article => {
          res.render('article/details', article)
      });
    }
};