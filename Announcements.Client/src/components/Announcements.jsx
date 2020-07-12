import React, { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';

// * Components
import { AnnouncementForm } from './AnnouncementForm';
import { AnnouncementItem } from './AnnouncementItem';
import { List } from './List';
import { Spinner } from './Spinner';

// * Images
import logo from 'assets/images/a';

// * Utils
import { getRequest, deleteRequest } from 'utils/helpers';
import { selectChosenAnnouncement } from 'utils/selectors/selectChosenAnnouncement'

// * Sass
import './Announcements.scss';
import { ChosenAnnouncement } from './ChosenAnnouncement/ChosenAnnouncement';

export const Announcements = () => {
  const chosenAnnouncement = useSelector(selectChosenAnnouncement);
  const [announcements, setAnnouncements] = useState(null);

  useEffect(() => {
    getAnnouncements();
  }, []);

  const getAnnouncements = async () => {
    const { status, data } = await getRequest('/announcements');

    if (status === 200)
      setAnnouncements(data);
    else
      setAnnouncements([]);
  }

  const onRemove = async id => {
    const { status } = await deleteRequest(`/announcements/${id}`);

    if (status === 204)
      await getAnnouncements();
  }

  return <div id="announcements">
    <div className="announcements__header">
      <img src={logo} alt="logo" className="announcements__logo" />
      <h2 className="announcements__logoPost">nnouncements</h2>
    </div>
    <div className="announcements__contentContainer">
      <ChosenAnnouncement {...chosenAnnouncement} />
      <div className="announcements__formSection">
        <h2 className="announcements__title">add annoucement</h2>
        <AnnouncementForm action="create" updateAnnouncements={getAnnouncements} />
      </div>
      <div className="announcements__listSection">
        <h2 className="announcements__title">annoucements</h2>
        {
          !announcements ?
            <Spinner /> :
            announcements.length == 0 ?
              <p className="announcements__noAnnouncements">there is no announcements right now.</p> :
              <List
                component={
                  props =>
                    <AnnouncementItem
                      onRemove={() => onRemove(props.id)}
                      chosenAnnouncementId={chosenAnnouncement && chosenAnnouncement.id}
                      updateAnnouncements={getAnnouncements}
                      {...props}
                    />
                }
                classNames={['announcements__list']}
                data={announcements}
              />
        }
      </div>
    </div>
  </div>;
}