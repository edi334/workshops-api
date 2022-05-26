import { Component, OnInit } from '@angular/core';
import {Participant} from "../../../models/participant";
import {ParticipantsService} from "../../services/participants.service";
import {MatDialog} from "@angular/material/dialog";
import {ParticipantsFormComponent} from "./participants-form/participants-form.component";

@Component({
  selector: 'app-participants',
  templateUrl: './participants.component.html',
  styleUrls: ['./participants.component.scss']
})
export class ParticipantsComponent implements OnInit {
  participants: Participant[] = [];

  constructor(
    private readonly _participantsService: ParticipantsService,
    private readonly _dialog: MatDialog
  ) { }

  async ngOnInit(): Promise<void> {
    this.participants = await this._participantsService.getAll();
  }

  async delete(id: string): Promise<void> {
    await this._participantsService.delete(id);
    this.participants = await this._participantsService.getAll();
  }

  openDialog(participant?: Participant): void {
    const dialogRef = this._dialog.open(ParticipantsFormComponent, {
      data: {participant: participant}
    });

    dialogRef.afterClosed().subscribe(async () => {
      this.participants = await this._participantsService.getAll();
    });
  }
}
