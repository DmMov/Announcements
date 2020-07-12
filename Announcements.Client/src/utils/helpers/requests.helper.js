import { get, post, put, delete as del } from 'axios';

// * Constants
import { apiUrl } from 'assets/constants/urls';

export const getRequest = async (url) => {
  try {
    return await get(apiUrl + url)
      .then(response => response)
      .catch(error => error.response);
  } catch (err) {
    console.log(err);
  }
}

export const postRequest = async (url, data) => {
  try {
    return await post(apiUrl + url, data)
      .then(response => response)
      .catch(error => error.response);
  } catch (err) {
    console.log(err);
  }
}

export const putRequest = async (url, data) => {
  try {
    return await put(apiUrl + url, data)
      .then(response => response)
      .catch(error => error.response);
  } catch (err) {
    console.log(err);
  }
}

export const deleteRequest = async (url) => {
  try {
    return await del(apiUrl + url)
      .then(response => response)
      .catch(error => error.response);
  } catch (err) {
    console.log(err);
  }
}