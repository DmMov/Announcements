import React, { useState } from 'react';

// * Components
import { Form } from 'components/Form';

// * Utils
import { useForm } from 'utils/hooks';
import { postRequest, putRequest } from 'utils/helpers';

// * Data
import { initialState } from './initialState';
import { initialFields } from './initialFields';
import { fieldsValidationSet } from './fieldsValidationSet';

export const AnnouncementForm = ({ formState, updateAnnouncements, action }) => {
  const [spin, setSpin] = useState(false);
  const { data, fields, validate, reset } = useForm(!!formState ? formState : initialState, initialFields);

  const onSubmit = async e => {
    e.preventDefault();
    setSpin(true);

    const isValid = validate(fieldsValidationSet);

    if (isValid) {
      let response;

      if (action === "create")
        response = await postRequest('/announcements', data);
      else if(action === "edit")
        response = await putRequest('/announcements', data);


      if (response.status === 200) {
        reset();
        updateAnnouncements();
      }
    }

    setSpin(false);
  };

  return <Form
    spin={spin}
    classes={['annoucementForm']}
    onSubmit={onSubmit}
    buttonText="submit"
    fields={fields}
  />;
}