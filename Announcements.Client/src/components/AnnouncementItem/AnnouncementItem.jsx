import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import classnames from 'classnames';

// * Components
import { AnnouncementForm } from '../AnnouncementForm';

// * Images
import edit from 'assets/images/edit';
import close from 'assets/images/close';
import remove from 'assets/images/remove';

// * Utils
import { getRequest } from 'utils/helpers';

// * Actions
import { setChosenAnnouncement } from 'store/actions';

// * Sass
import './AnnouncementItem.scss';

export const AnnouncementItem = ({ id, title, description, chosenAnnouncementId, onRemove, ...props }) => {
  const [editMode, setEditMode] = useState(false);
  const dispatch = useDispatch();

  const formState = { id, title, description };

  const seeDetails = async () => {
    const { status, data } = await getRequest(`/announcements/${id}`);

    if (status === 200)
      dispatch(setChosenAnnouncement(data))
  }

  return <>
    <button className="btn editToggleBtn" onClick={() => setEditMode(mode => !mode)}>
      {
        editMode ?
          <img src={close} alt="close" className="closeIcon" /> :
          <img src={edit} alt="edit" className="editIcon" />
      }
    </button>
    {
      !editMode ?
        <div className={classnames('announcementItem', chosenAnnouncementId == id && 'chosen')}>
          <h3 className="announcementItem__title">{title}</h3>
          <span className="announcementItem__description">{description.slice(0, 50)}...</span>
          <button className="btn announcementItem__seeDetailsBtn" onClick={seeDetails}>see details →</button>
          <button className="btn announcementItem__removeBtn" onClick={onRemove}>
            <img src={remove} alt="remove" className="removeIcon" />
          </button>
        </div> :
        <AnnouncementForm action="edit" formState={formState} {...props} />
    }
  </>;
}
