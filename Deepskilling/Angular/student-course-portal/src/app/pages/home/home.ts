import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  imports: [FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class HomeComponent implements OnInit, OnDestroy {

  portalName = 'Student Course Portal';
  isPortalActive = true;
  searchTerm = '';
  message = '';

  ngOnInit(): void {
    console.log('Home loaded');
  }

  onEnrollClick(): void {
    this.message = 'Enrollment opened!';
  }

  ngOnDestroy(): void {
    console.log('Home destroyed');
  }
}