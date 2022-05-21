import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {WorkshopsService} from "../../../services/workshops.service";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-workshops-form',
  templateUrl: './workshops-form.component.html',
  styleUrls: ['./workshops-form.component.scss']
})
export class WorkshopsFormComponent {
  form = this._formBuilder.group({
    name: ['', [Validators.required]],
    description: ['', [Validators.required]],
    category: ['', [Validators.required]]
  });

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _workshopsService: WorkshopsService,
    private readonly _dialogRef: MatDialogRef<WorkshopsFormComponent>
  ) { }

  async save(): Promise<void> {
    this.form.markAllAsTouched();
    if (!this.form.valid) {
      window.alert('Form not valid!');
      return;
    }

    try {
      await this._workshopsService.post(this.form.value);
    } catch {
      window.alert('Oops something went wrong!');
    }

    this._dialogRef.close();
  }
}
