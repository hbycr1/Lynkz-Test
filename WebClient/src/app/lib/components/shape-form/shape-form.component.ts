import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ShapeService } from '../../services/shape-api.service';
import { take } from 'rxjs';
import { ShapeResponse } from '../../models/shape-response.model';
import { ApiResult } from '../../models/api-response.model';
import { ShapeCanvasComponent } from '../shape-canvas/shape-canvas.component';

@Component({
  selector: 'app-shape-form',
  templateUrl: './shape-form.component.html',
  styleUrl: './shape-form.component.scss',
  imports: [ReactiveFormsModule, CommonModule, ShapeCanvasComponent],
})
export class ShapeFormComponent {
  constructor(private shapeService: ShapeService) {}

  shapeData?: ShapeResponse;
  submitting = false;
  errorText = '';
  shapeForm = new FormGroup({
    shapeDescription: new FormControl(
      `Draw a circle with a radius of 120`,
      Validators.required
    ),
  });

  createShape = () => {
    if (!this.submitting) {
      const { shapeDescription } = this.shapeForm.controls;

      // reset previous error message
      if (this.errorText.length) this.errorText = '';

      // validate there is a value in the input field
      if (shapeDescription.invalid) {
        this.errorText =
          'Please enter your shape details using the format provided';
        return;
      }

      this.submitting = true;
      this.shapeData = undefined; // reset the shape data to prevent displaying old data
      this.shapeForm.disable(); // disable the form to prevent multiple submissions

      // submit
      this.shapeService
        .get(shapeDescription.value!)
        .pipe(take(1)) // this will unsubscribe from the observable after the first value is emitted
        .subscribe({
          next: (response: ApiResult<ShapeResponse>) => {
            if (response.isValid) {
              this.shapeData = response.model;
            } else {
              this.errorText = response.errors[0];
            }

            this.submitting = false;
            this.shapeForm.enable();
          },
          error: (error) => {
            this.submitting = false;
            this.shapeForm.enable();
          },
        });
    }
  };
}
