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

import React, { useState } from 'react';
import { BsPlus } from "react-icons/bs";

const CreateTodoField = ({ addTask }) => {

    const [title, setTitle] = useState('');

    return (
        <div className='text-lg w-full flex items-center mb-3 rounded-lg px-1 py-2'>
            <button onClick={() => {
                addTask(title);
                setTitle('');
            }}>
                <BsPlus size={22} className='border-2 rounded-lg border-blue-500 text-white bg-blue-500 w-9 h-9 mr-3' />
            </button>
            <input type="text"
                onChange={e => setTitle(e.target.value)}
                value={title}
                onKeyUp={e => {
                    if (e.key === 'Enter') {
                        addTask(title);
                        setTitle('');
                    }
                }}
                placeholder='Add a task'
                className='bg-transparent text-lg w-full border-none outline-none' />
        </div>
    );
};

export default CreateTodoField;