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

import React from 'react';
import { RxCross2 } from "react-icons/rx";
import cn from 'classnames';
import Checkbox from './Checkbox';

const TodoItem = ({ task, changeTask, removeTask }) => {
    return (
        <div className='text-lg w-full flex items-center justify-between mb-2 rounded-lg p-3 bg-gray-700' >
            <button className='flex items-center w-full h-full text-left' onClick={() => changeTask(task._id)} >
                <Checkbox isCompleted={task.isCompleted} />
                <span className={cn({ 'line-through': task.isCompleted })}>{task.title}</span>
            </button>
            <button onClick={() => removeTask(task._id)}>
                <RxCross2 size={26} className='text-gray-500 hover:text-red-600' />
            </button>
        </div>
    );
};

export default TodoItem;
