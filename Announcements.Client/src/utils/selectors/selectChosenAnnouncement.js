import { createSelector } from "reselect";

export const selectChosenAnnouncement = createSelector(
  state => state.chosenAnnouncement,
  chosenAnnouncement => chosenAnnouncement
);