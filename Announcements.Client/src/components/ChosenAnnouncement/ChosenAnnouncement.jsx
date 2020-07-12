import React from 'react';

// * Components
import { List } from '../List';
import { AnnouncementItem } from '../AnnouncementItem';

// * Sass
import './ChosenAnnouncement.scss';

export const ChosenAnnouncement = ({ id, title, description, createdAt, similarAnnouncements }) => id ?
  <div className="chosenAnnouncement">
    <p className="chosenAnnouncement__createdAt">{createdAt}</p>
    <h2 className="chosenAnnouncement__title">{title}</h2>
    <p className="chosenAnnouncement__description">{description}</p>
    <p className="chosenAnnouncement__subTitle">similar announcements ↓</p>
    <List
      component={AnnouncementItem}
      classNames={['chosenAnnouncement__similarAnnouncements']}
      data={similarAnnouncements}
    />
  </div> :
  <p className="notChosen">choose an announcement.</p>;
