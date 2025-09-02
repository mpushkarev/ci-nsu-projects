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

const Layout = ({ children }) => {
    return (
        <div className='bg-gray-800 min-h-screen h-full text-white py-10'>
            {children}
        </div>
    );
};

export default Layout;
