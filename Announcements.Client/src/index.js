import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';

// * Sass
import 'assets/scss';

// * Store
import { store } from 'store/store';

import(/* webpackChunkName: 'announcements' */ 'components/Announcements')
  .then(({ Announcements }) =>
    render(
      <Provider store={store}>
        <Announcements />
      </Provider>,
      document.getElementById('app')
    )
  );