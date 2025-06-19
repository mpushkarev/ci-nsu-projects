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
import { BsCheck } from 'react-icons/bs';
import cn from 'classnames';

const Checkbox = ({ isCompleted }) => {
    return (
        <div className={cn('border-2 rounded-lg border-blue-400 w-6 h-6 mr-3 flex items-center', {
            'bg-blue-400': isCompleted
        })}>
            {isCompleted && <BsCheck size={26} className='text-white' />}
        </div>
    );
};

export default Checkbox;
