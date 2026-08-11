import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HighlightDirective } from '../../directives/highlight';
import { CreditLabelPipe } from '../../pipes/credit-label-pipe';

@Component({
  selector: 'app-course-card',
  imports: [CommonModule, HighlightDirective, CreditLabelPipe],
  templateUrl: './course-card.html',
  styleUrl: './course-card.css'
})
export class CourseCardComponent {
  @Input() course: any;

  isEnrolled = false;
  isExpanded = false;

  get cardClasses() {
    return {
      'card--enrolled': this.isEnrolled,
      'card--full': this.course?.credits >= 4,
      'expanded': this.isExpanded
    };
  }

  get borderColor(): string {
    switch (this.course?.gradeStatus) {
      case 'passed': return 'green';
      case 'failed': return 'red';
      default: return 'grey';
    }
  }

  toggleDetails(): void {
    this.isExpanded = !this.isExpanded;
  }
}