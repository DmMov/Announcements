export const isEmpty = obj => {
  for (const _ in obj) {
    return false;
  }

  return true;
}