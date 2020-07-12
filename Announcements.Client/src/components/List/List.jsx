import React from 'react';
import classnames from 'classnames';

export const List = ({ classNames, component: Component, data }) =>
  <div className={classnames('list', ...classNames)}>
    {data.map(item => <Component key={item.id} {...item} />)}
  </div>;
