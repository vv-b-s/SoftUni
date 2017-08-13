const mongoose = require('mongoose');

let taskSchema = mongoose.Schema(
    {
        title:{type: String, required: true, unique: false},
        comments:{type: String, required: false, unique: false}
    }
);

const Task = mongoose.model('Task', taskSchema);

module.exports = Task;