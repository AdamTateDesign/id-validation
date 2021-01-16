import ValidationResult from "./validation-result";

export default interface FileValidationResult {
  idCount: number;
  invalidCheckDigitCount: number;
  invalidOtherCount: number;
  validCount: number;
  results: ValidationResult[];
}
