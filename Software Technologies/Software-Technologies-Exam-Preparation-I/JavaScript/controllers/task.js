const Task = require('../models/Task');

module.exports = {
    index: (req, res) => {
        Task.find({}).then(tasks=>{
            res.render('task/index', {'tasks': tasks});
		});
    },
	createGet: (req, res) => {
        res.render('task/create');
	},
	createPost: (req, res) => {
        let task = {
        	title: req.body.title,
			comments: req.body.comments
		};

        Task.create(task);
        res.redirect('/');
	},
	deleteGet: (req, res) => {
        let id = req.params.id;
        Task.findById(id).then(
        	task => {
        		if(task)
        			res.render('task/delete', {'id':task.id ,'title': task.title, 'comments': task.comments});
        		else
        			res.redirect('/');
			}
		)
	},
	deletePost: (req, res) => {
        let id = req.params.id;
        Task.findById(id).remove().exec();
        res.redirect('/');
	}
};