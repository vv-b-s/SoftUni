const encryption = require("./../utilities/encryption");
const User = require('mongoose').model('User');

module.exports = {
    registerGet: (req, res) => {
        res.render('user/register');
    },
    registerPost:(req, res) => {
        let userData = req.body;

        User.findOne({email: userData.email}).then(user => {
            let errorMsg = '';
            if (user) {
                errorMsg = 'User with the same username exists!';
            } else if (userData.password !== userData.repeatedPassword) {
                errorMsg = 'Passwords do not match!'
            }

            if (errorMsg) {
                userData.error = errorMsg;
                res.render('user/register', userData)
            } else {
                let salt = encryption.generateSalt();
                let passwordHash = encryption.hashPassword(userData.password, salt);

                let userObject = {
                    email: userData.email,
                    passwordHash: passwordHash,
                    fullName: userData.fullName,
                    salt: salt
                };

                User.create(userObject).then(user => {
                    req.logIn(user, (err) => {
                        if (err) {
                            userData.error = err.message;
                            res.render('user/register', userData);
                            return;
                        }

                        res.redirect('/')
                    })
                })
            }
        })
    },

    loginGet: (req, res) => {
        res.render('user/login');
    },
    loginPost: (req, res) => {
        let userData = req.body;

        User.findOne({email: userData.email})
            .then(user => {
                let errorMsg = '';
                if(!user||!user.authenticate(userData.password)){
                    errorMsg = 'Either username or password is invalid!';
                    userData.error = errorMsg;
                    res.render('user/login',userData);
                    return;
                }

                req.logIn(user, (err) => {
                    if (err) {
                        console.log(err);
                        res.redirect('/user/login', {error: err.message});
                        return;
                    }

                    res.redirect('/');
                })
            });
    },

    logout: (req, res)=> {
        req.logOut();
        res.redirect('/')
    }
};