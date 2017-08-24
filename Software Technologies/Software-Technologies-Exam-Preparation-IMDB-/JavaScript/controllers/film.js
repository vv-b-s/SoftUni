const Film = require('../models/Film');

module.exports = {
	index: (req, res) => {
        Film.find().then(films=>{ res.render('film/index',{films: films} );});
	},
	createGet: (req, res) => {
       res.render('./film/create');
	},
	createPost: (req, res) => {
        let film = {
            name: req.body.name,
            genre: req.body.genre,
            director: req.body.director,
            year: Number(req.body.year)
        };

        Film.create(film).then(()=>res.redirect('/'));

    },
	editGet: (req, res) => {
		let id = req.params.id;
        Film.findById(id).then(film => res.render('./film/edit',{film:film})).catch(err=>res.redirect('/'));
	},
	editPost: (req, res) => {
		let id = req.params.id;
        Film.findByIdAndUpdate(id, req.body,{runValidators: true})
			.then(()=>res.redirect('/'))
			.catch(err=>res.redirect(`/edit/${id}`));
	},
	deleteGet: (req, res) => {
        let id = req.params.id;
        Film.findById(id).then(film => res.render('./film/delete',{film:film})).catch(err=>res.redirect('/'));
	},
	deletePost: (req, res) => {
        let id = req.params.id;
        Film.findByIdAndRemove(id)
            .then(()=>res.redirect('/'));
	}
};