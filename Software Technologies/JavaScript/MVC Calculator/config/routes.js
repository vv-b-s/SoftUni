const homeController = require('./../controllers/home');

module.exports = (app) => {                         // decides where to send data to
    app.get('/', homeController.indexGet);
    app.post('/',homeController.indexPost);
};

