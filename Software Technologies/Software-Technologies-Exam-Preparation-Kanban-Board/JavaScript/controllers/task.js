const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {
		Task.find({}).then(tasks=>
		{
            let openTasks 		= tasks.filter(t=>t.status === "Open");
            let inProgressTasks = tasks.filter(t=>t.status === "In Progress");
            let finishedTasks 	= tasks.filter(t=>t.status === "Finished");

            res.render('./task/index',{
                openTasks: openTasks,
                inProgressTasks: inProgressTasks,
                finishedTasks: finishedTasks
            });
		});
	},
	createGet: (req, res) => {
		res.render('task/create');
	},
	createPost: (req, res) => {
		let taskItems = req.body;
		let task = {
			title: taskItems.title,
			status: taskItems.status
		};

		if(!task.title)
			res.redirect('/create');

		Task.create(task).then(task=>res.redirect('/'));
	},
	editGet: (req, res) => {
		let id = req.params.id;
		Task.findById(id).then(task =>{
			if(!task)
				res.redirect('/');

            res.render('task/edit',{
                title: task.title,
                status: task.status,
                id:id
            });
		});

	},
	editPost: (req, res) => {
		let id = req.params.id;
		let task = req.body;

		Task.findByIdAndUpdate(id, task, {runValidators: true}).then(()=>res.redirect('/'))
			.catch(err=>res.redirect(`/edit/${id}`));
	},

	delete: (req, res) =>{
		let id = req.params.id;
		Task.findByIdAndRemove(id).then(()=>res.redirect('/')).catch(err=>res.redirect('/'));
	}
};