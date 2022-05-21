import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {ParticipantsService} from "../../../services/participants.service";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-participants-form',
  templateUrl: './participants-form.component.html',
  styleUrls: ['./participants-form.component.scss']
})
export class ParticipantsFormComponent {
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
    private readonly _dialogRef: MatDialogRef<ParticipantsFormComponent>
  ) { }

  async save(): Promise<void> {
    this.form.markAllAsTouched();
    if (!this.form.valid) {
      window.alert('Form not valid!');
      return;
    }

    try {
      await this._participantsService.post(this.form.value);
    } catch {
      window.alert('Oops something went wrong!');
    }

    this._dialogRef.close();
  }
}
