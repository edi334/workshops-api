import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {WorkshopsService} from "../../../services/workshops.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {Workshop} from '../../../../models/workshop';

interface DialogData {
  workshop: Workshop;
}

@Component({
  selector: 'app-workshops-form',
  templateUrl: './workshops-form.component.html',
  styleUrls: ['./workshops-form.component.scss']
})
export class WorkshopsFormComponent implements OnInit {
  form = this._formBuilder.group({
    name: ['', [Validators.required]],
    description: ['', [Validators.required]],
    category: ['', [Validators.required]]
  });

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _workshopsService: WorkshopsService,
    private readonly _dialogRef: MatDialogRef<WorkshopsFormComponent>,
    @Inject(MAT_DIALOG_DATA) private readonly _data: DialogData
  ) { }

  async save(): Promise<void> {
    this.form.markAllAsTouched();
    if (!this.form.valid) {
      window.alert('Form not valid!');
      return;
    }

    try {
      if (this._data.workshop) {
        await this._workshopsService.patch(this._data.workshop.id, this.form.value);
      } else {
        await this._workshopsService.post(this.form.value);
      }
    } catch {
      window.alert('Oops something went wrong!');
    }

    this._dialogRef.close();
  }

  ngOnInit(): void {
    if (this._data.workshop) {
      this.form.patchValue(this._data.workshop);
    }
  }
}
