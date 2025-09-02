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
import ReactDOM from 'react-dom/client';
import './index.css';
import Layout from './components/Layout/Layout';
import Home from './components/screens/Home/Home';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <Layout>
      <Home />
    </Layout>
  </React.StrictMode>
);
