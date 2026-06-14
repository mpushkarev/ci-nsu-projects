/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. February – June 2025                                    *
*                                                                              *
*  Description:                                                                *
*    This project is a very simple to-do list application                      *
*    built in React. It allows users to add, check off, and delete tasks.      *
*    It was created as my first experience using React and npm,                *
*    and was completed in a single evening. As a result, the code is quite     *
*    basic and likely contains various flaws and areas for improvement.        *
*    Nevertheless, it serves as an introduction to the fundamental             *
*    concepts of React development and working with npm.                       *
*                                                                              *
\******************************************************************************/

import React, { useState } from "react";
import TodoItem from "./TodoItem/TodoItem";
import CreateTodoField from "./CreateTodoField";

const data = [
    {
        _id: 1,
        title: "Сложить в лукошко",
        isCompleted: false
    },
    {
        _id: 2,
        title: "Полить картошку",
        isCompleted: false
    },
    {
        _id: 3,
        title: "Покормить кошку",
        isCompleted: false
    }
];

const Home = () => {

    const [todos, setTodos] = useState(data);

    const changeTask = (id) => {
        const copy = [...todos];
        const current = copy.find(t => t._id === id);
        current.isCompleted = !current.isCompleted;
        setTodos(copy);
    };

    const removeTask = (id) => {
        const copy = [...todos];
        const result = copy.filter(t => t._id !== id);
        setTodos(result);
    };

    const addTask = (title) => {
        if (title !== '') {
            const newTask = {
                _id: todos.length ? todos[todos.length - 1]._id + 1 : 1,
                title,
                isCompleted: false
            };
            setTodos([...todos, newTask]);
        } else {
            alert("Ooops!")
        }
    };

    return (
        <div className="w-5/6 mx-auto">
            <h1 className="text-2xl font-bold mb-4">Crazy TODO</h1>
            <CreateTodoField addTask={addTask} />
            <div className="">
                {todos.slice().reverse().map(task => (
                    <TodoItem key={task._id} task={task} changeTask={changeTask} removeTask={removeTask} />
                ))}
            </div>
        </div>
    );
}

export default Home;
