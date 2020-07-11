import React from 'react';
import { render } from 'react-dom';

// * Sass
import 'assets/scss';

import(/* webpackChunkName: 'announcements' */ 'components/Announcements')
  .then(({ Announcements }) =>
    render(<Announcements />,document.getElementById('app'))
  );