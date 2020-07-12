export const equalFields = (basePropertyKey, propertyKeyToCompare) => (data, setErrors) => {
  if (data[propertyKeyToCompare] === data[basePropertyKey])
    return true;

  setErrors(errors => ({
    ...errors,
    [propertyKeyToCompare]:
      errors[propertyKeyToCompare] === '' ?
        `this field must equal to the ${basePropertyKey} field.` :
        errors[propertyKeyToCompare]
  }));

  return false;
}