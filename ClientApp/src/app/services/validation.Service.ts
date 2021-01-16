import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import ValidationResult from "../models/validation-result";

export default class ValidationService {
  constructor(private httpClient : HttpClient) {
  }

  validateId(id: string): Observable<ValidationResult> {
    return this.httpClient.post<ValidationResult>("/validate-id", id);
  }
}
