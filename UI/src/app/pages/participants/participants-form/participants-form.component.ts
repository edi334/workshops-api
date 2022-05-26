import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {ParticipantsService} from "../../../services/participants.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {Participant} from '../../../../models/participant';

interface DialogData {
  participant?: Participant
}

@Component({
  selector: 'app-participants-form',
  templateUrl: './participants-form.component.html',
  styleUrls: ['./participants-form.component.scss']
})
export class ParticipantsFormComponent implements OnInit {
  form = this._formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    phoneNumber: ['', [Validators.required,
      Validators.pattern('^(\\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\\s|\\.|\\-)?([0-9]{3}(\\s|\\.|\\-|)){2}$')]]
  });

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _participantsService: ParticipantsService,
    private readonly _dialogRef: MatDialogRef<ParticipantsFormComponent>,
    @Inject(MAT_DIALOG_DATA) private readonly _data: DialogData
  ) { }

  async save(): Promise<void> {
    this.form.markAllAsTouched();
    if (!this.form.valid) {
      window.alert('Form not valid!');
      return;
    }

    try {
      if (this._data.participant) {
          await this._participantsService.patch(this._data.participant.id, this.form.value);
      } else {
        await this._participantsService.post(this.form.value);
      }
    } catch {
      window.alert('Oops something went wrong!');
    }

    this._dialogRef.close();
  }

  ngOnInit(): void {
    if (this._data.participant) {
      this.form.patchValue(this._data.participant);
    }
  }
}
