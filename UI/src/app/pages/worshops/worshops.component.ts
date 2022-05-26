import { Component, OnInit } from '@angular/core';
import {Workshop} from "../../../models/workshop";
import {firstValueFrom} from "rxjs";
import {WorkshopsService} from "../../services/workshops.service";
import {MatDialog} from "@angular/material/dialog";
import {WorkshopsFormComponent} from "./workshops-form/workshops-form.component";

@Component({
  selector: 'app-worshops',
  templateUrl: './worshops.component.html',
  styleUrls: ['./worshops.component.scss']
})
export class WorshopsComponent implements OnInit {
  workshops: Workshop[] = [];

  constructor(
    private readonly _workshopsService: WorkshopsService,
    private readonly _dialog: MatDialog
  ) { }

  async ngOnInit(): Promise<void> {
    this.workshops = await this._workshopsService.getAll();
  }

  async delete(id: string): Promise<void> {
    await this._workshopsService.delete(id);
    this.workshops = await this._workshopsService.getAll();
  }

  openDialog(workshop?: Workshop): void {
    const dialogRef = this._dialog.open(WorkshopsFormComponent, {
      data: {workshop: workshop}
    });

    dialogRef.afterClosed().subscribe(async () => {
      this.workshops = await this._workshopsService.getAll();
    })
  }

}
