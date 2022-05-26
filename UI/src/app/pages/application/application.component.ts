import { Component, OnInit } from '@angular/core';
import {ApplicationResponse} from "../../../models/application-response";
import {ApplicationsService} from "../../services/applications.service";
import {MatDialog} from "@angular/material/dialog";
import {ApplicationsFormComponent} from "./applications-form/applications-form.component";
import {ParticipantsService} from "../../services/participants.service";
import {WorkshopsService} from "../../services/workshops.service";
import {Application} from '../../../models/application';

@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.scss']
})
export class ApplicationComponent implements OnInit {
  applications: ApplicationResponse[] = [];

  constructor(
    private readonly _applicationsService: ApplicationsService,
    private readonly _participantsService: ParticipantsService,
    private readonly _workshopsService: WorkshopsService,
    private readonly _dialog: MatDialog
  ) { }

  async ngOnInit(): Promise<void> {
    this.applications = await this._applicationsService.getAll();
  }

  async delete(id: string): Promise<void> {
    await this._applicationsService.delete(id);
    this.applications = await this._applicationsService.getAll();
  }

  async openDialog(application?: ApplicationResponse): Promise<void> {
    const participants = (await this._participantsService.getAll())
      .filter(p => this.applications.map(a => a.participant).find(x => x.id === p.id) === undefined);
    const workshops = await this._workshopsService.getAll();

    const dialogRef = this._dialog.open(ApplicationsFormComponent, {
      data: {participants: participants, workshops: workshops, application: application}
    });

    dialogRef.afterClosed().subscribe(async () => {
      this.applications = await this._applicationsService.getAll();
    });
  }
}
