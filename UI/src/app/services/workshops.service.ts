import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {firstValueFrom} from "rxjs";
import {Workshop} from "../../models/workshop";

@Injectable({
  providedIn: 'root'
})
export class WorkshopsService {
  private readonly _baseUrl = environment.apiUrl + 'api/workshop';

  constructor(
    private readonly _http: HttpClient
  ) { }

  async getById(id: string): Promise<Workshop> {
    const url = this._baseUrl + `/${id}`;
    return await firstValueFrom(this._http.get<Workshop>(url));
  }

  async getAll(): Promise<Workshop[]> {
    return await firstValueFrom(this._http.get<Workshop[]>(this._baseUrl));
  }

  async post(workshop: Workshop): Promise<Workshop> {
    return await firstValueFrom(this._http.post<Workshop>(this._baseUrl, workshop));
  }

  async delete(id: string): Promise<Workshop> {
    const url = this._baseUrl + `/${id}`;
    return await firstValueFrom(this._http.delete<Workshop>(url));
  }

  async patch(id: string, workshop: Workshop): Promise<Workshop> {
    const url = this._baseUrl + `/${id}`;
    return await firstValueFrom(this._http.patch<Workshop>(url, workshop));
  }
}
