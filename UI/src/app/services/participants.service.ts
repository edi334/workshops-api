import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {firstValueFrom} from "rxjs";
import {Participant} from "../../models/participant";

@Injectable({
  providedIn: 'root'
})
export class ParticipantsService {
  private readonly _baseUrl = environment.apiUrl + 'api/participant';

  constructor(
    private readonly _http: HttpClient
  ) {
  }

  async getById(id: string): Promise<Participant> {
    const url = this._baseUrl + `/${id}`;
    return await firstValueFrom(this._http.get<Participant>(url));
  }

  async getAll(): Promise<Participant[]> {
    return await firstValueFrom(this._http.get<Participant[]>(this._baseUrl));
  }

  async post(participant: Participant): Promise<Participant> {
    return await firstValueFrom(this._http.post<Participant>(this._baseUrl, participant));
  }

  async delete(id: string): Promise<Participant> {
    const url = this._baseUrl + `/${id}`;
    return await firstValueFrom(this._http.delete<Participant>(url));
  }

  async patch(id: string, participant: Participant): Promise<Participant> {
    const url = this._baseUrl + `/${id}`;
    return await firstValueFrom(this._http.patch<Participant>(url, participant));
  }
}
