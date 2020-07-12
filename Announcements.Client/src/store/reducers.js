import { SET_CHOSEN_ANNOUNCEMENT } from './actions';

const defaultState = {
  chosenAnnouncement: null
};

export const reducer = (state = defaultState, { type, payload }) => {
  switch(type) {
    case SET_CHOSEN_ANNOUNCEMENT:
      return {
        chosenAnnouncement: payload
      };
  }

  return state;
}