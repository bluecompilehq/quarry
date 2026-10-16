import { Component } from '@angular/core';

@Component({
  selector: 'app-top-bar',
  imports: [],
  templateUrl: './top-bar.html',
  styleUrl: './top-bar.css',
  host: {
    class: 'h-13 shrink-0 flex items-center px-4 border-b border-line bg-panel'
  }
})
export class TopBar {}
