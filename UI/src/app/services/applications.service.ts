import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {ApplicationResponse} from "../../models/application-response";
import {firstValueFrom} from "rxjs";
import {ApplicationRequest} from "../../models/application-request";
import {Participant} from "../../models/participant";
import {Application} from '../../models/application';

@Injectable({
  providedIn: 'root'
})
export class ApplicationsService {
  private readonly _baseUrl = environment.apiUrl + 'api/application';

  constructor(
    private readonly _http: HttpClient
  ) { }

  async getAll(): Promise<ApplicationResponse[]> {
    return await firstValueFrom(this._http.get<ApplicationResponse[]>(this._baseUrl));
  }

  async post(application: ApplicationRequest): Promise<ApplicationResponse> {
    return await firstValueFrom(this._http.post<ApplicationResponse>(this._baseUrl, application));
  }

  async delete(id: string): Promise<ApplicationResponse> {
    const url = this._baseUrl + `/${id}`;
    return await firstValueFrom(this._http.delete<ApplicationResponse>(url));
  }

  async patch(id: string, application: ApplicationRequest): Promise<ApplicationResponse> {
    const url = this._baseUrl + `/${id}`;
    return await firstValueFrom(this._http.patch<ApplicationResponse>(url, application));
  }
}
