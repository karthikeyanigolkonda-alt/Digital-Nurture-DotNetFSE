import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseCardComponent } from '../../components/course-card/course-card';

@Component({
  selector: 'app-course-list',
  imports: [CommonModule, CourseCardComponent],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseListComponent implements OnInit, OnDestroy {

  isLoading = true;
  selectedCourseId: number | null = null;

  courses = [
    { id: 1, name: 'Data Structures', code: 'CS101', credits: 4, status: 'passed', gradeStatus: 'passed' },
    { id: 2, name: 'Database Systems', code: 'CS102', credits: 4, status: 'pending', gradeStatus: 'pending' },
    { id: 3, name: 'Computer Networks', code: 'CS103', credits: 3, status: 'passed', gradeStatus: 'passed' },
    { id: 4, name: 'Artificial Intelligence', code: 'CS104', credits: 4, status: 'failed', gradeStatus: 'failed' }
  ];

  ngOnInit(): void {
    setTimeout(() => {
      this.isLoading = false;
    }, 1500);
  }

  enroll(id: number): void {
    this.selectedCourseId = id;
  }

  trackByCourseId(index: number, course: any): number {
    return course.id;
  }

  ngOnDestroy(): void {
    console.log('Course list destroyed');
  }
}