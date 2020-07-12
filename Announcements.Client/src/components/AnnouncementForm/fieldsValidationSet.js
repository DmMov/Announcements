// * Utils
import { required, minLength } from 'utils/validators';

export const fieldsValidationSet = {
  title: [
    [required, 'title is required.'],
    [minLength(12), 'title must contain at least 12 characters.'],
  ],
  description: [
    [required, 'description is required.'],
    [minLength(64), 'description must contain at least 64 characters.']
  ]
};