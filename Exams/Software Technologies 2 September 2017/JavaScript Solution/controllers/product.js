const Product = require('../models/Product');

module.exports = {
	index: (req, res) => {
        	Product.find({}).then(products=>{
        		products.sort((p1,p2)=>p1.priority>p2.priority);
        		res.render('./product/index',{products: products});
			})
    	},
	createGet: (req, res) => {
        res.render('./product/create');
	},
	createPost: (req, res) => {
		let bodyParams = req.body;
		let product = {
			priority: bodyParams.priority,
			name: bodyParams.name,
            quantity: bodyParams.quantity,
			status:bodyParams.status
		};

		Product.create(product).then(()=>res.redirect('/')).catch(err=>{
			console.log(err);
			res.redirect('/create')})
	},
	editGet: (req, res) => {
        Product.findById(req.params.id).then(product=>res.render('./product/edit',{product:product})).catch(err=>res.redirect('/'));
	},
	editPost: (req, res) => {
		let product = req.body;
        Product.findByIdAndUpdate(req.params.id, product, {runValidators: true}).then(()=>res.redirect('/')).catch(err=>res.redirect(`/edit/${req.params.id}`));
	}
};