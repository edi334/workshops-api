import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {ApplicationsService} from "../../../services/applications.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {Participant} from "../../../../models/participant";
import {Workshop} from "../../../../models/workshop";
import {Application} from '../../../../models/application';
import {ApplicationResponse} from '../../../../models/application-response';

interface DialogData {
  participants: Participant[];
  workshops: Workshop[];
  application: ApplicationResponse;
}

@Component({
  selector: 'app-applications-form',
  templateUrl: './applications-form.component.html',
  styleUrls: ['./applications-form.component.scss']
})
export class ApplicationsFormComponent implements OnInit {
  form = this._formBuilder.group({
    country: ['', [Validators.required]],
    university: ['', [Validators.required]],
    fieldOfStudy: ['', [Validators.required]],
    reason: ['', [Validators.required]],
    participantId: ['', [Validators.required]],
    workshopId: ['', [Validators.required]],
  });

  constructor(
    private readonly _formBuilder: FormBuilder,
    private readonly _applicationsService: ApplicationsService,
    private readonly _dialogRef: MatDialogRef<ApplicationsFormComponent>,
    @Inject(MAT_DIALOG_DATA) readonly data: DialogData
  ) { }

  async save(): Promise<void> {
    this.form.markAllAsTouched();
    if (!this.form.valid) {
      window.alert('Form not valid!');
      return;
    }

    try {
      if (this.data.application) {
        await this._applicationsService.patch(this.data.application.id, this.form.value);
      } else {
        await this._applicationsService.post(this.form.value);
      }
    } catch {
      window.alert('Oops something went wrong!');
    }

    this._dialogRef.close();
  }

  async ngOnInit(): Promise<void> {
    if (this.data.application) {
      this.form.patchValue(this.data.application);
      this.form.get('participantId')?.patchValue(this.data.application.participant.id);
      this.form.get('workshopId')?.patchValue(this.data.application.workshop.id);
      console.log(this.form.value);
    }
  }
}
