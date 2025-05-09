import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { ShapeData, ShapeResponse } from '../../models/shape-response.model';
import * as d3 from 'd3';
import { ShapeType } from '../../enum/shape-type.enum';

@Component({
  selector: 'app-shape-canvas',
  templateUrl: './shape-canvas.component.html',
})
export class ShapeCanvasComponent {
  @Input() shapeData?: ShapeResponse;
  @ViewChild('shapeSvg', { static: true }) shapeSvg!: ElementRef<SVGElement>;

  errorText?: string;

  ngOnInit() {
    if (!this.shapeData) {
      this.errorText = 'No shape data provided';
      return;
    }

    // check shape type
    this.createShapeSvg();
  }

  createShapeSvg = () => {
    if (this.shapeData) {
      const svg = d3.select(this.shapeSvg.nativeElement);

      // clear previous shapes
      svg.selectAll('*').remove();

      // Create a group for the shape and center it
      const shapeGroup = svg.append('g');

      switch (this.shapeData.type) {
        case ShapeType.Circle: {
          const { width, height, radius } = this.shapeData.data;
          svg.attr('width', width).attr('height', height);
          shapeGroup
            .append('circle')
            .attr('cx', radius)
            .attr('cy', radius)
            .attr('r', radius)
            .attr('fill', '#122033');
          break;
        }
        case ShapeType.Oval: {
          const { width, height, rx, ry } = this.shapeData.data;
          svg.attr('width', width).attr('height', height);
          shapeGroup
            .append('ellipse')
            .attr('cx', rx)
            .attr('cy', ry)
            .attr('rx', rx)
            .attr('ry', ry)
            .attr('fill', '#122033');
          break;
        }
        case ShapeType.Square:
        case ShapeType.Rectangle: {
          const { width, height } = this.shapeData.data;
          svg.attr('width', width).attr('height', height);
          shapeGroup
            .append('rect')
            .attr('width', width)
            .attr('height', height)
            .attr('fill', '#122033');
          break;
        }
        case ShapeType.IsoscelesTriangle:
        case ShapeType.ScaleneTriangle:
        case ShapeType.EquilateralTriangle:
        case ShapeType.Heptagon:
        case ShapeType.Hexagon:
        case ShapeType.Octagon:
        case ShapeType.Pentagon: {
          const { width, height, points } = this.shapeData.data;
          svg.attr('width', width).attr('height', height);
          // Create polygon from points
          const pathGenerator = d3
            .line()
            .x((d: any) => d.x)
            .y((d: any) => d.y);
          shapeGroup
            .attr('transform', `translate(${width / 2}, ${height / 2})`)
            .append('path')
            .attr('d', pathGenerator(points as any[]));
          break;
        }
      }
    }
  };
}
