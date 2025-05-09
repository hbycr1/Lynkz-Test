import { Component } from '@angular/core';
import { AppLogoComponent } from './lib/components/logo/logo.component';
import { ShapeFormComponent } from './lib/components/shape-form/shape-form.component';

@Component({
  selector: 'app-root',
  imports: [AppLogoComponent, ShapeFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'Shapez';
  description =
    'Generate a shape with a specific measurement by using the following format:';
  format = `Draw a(n) <shape> with a(n) <measurement> of <amount> (and a(n) <measurement> of <amount>)`;
}
