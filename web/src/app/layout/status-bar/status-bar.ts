import { Component } from '@angular/core';

@Component({
  selector: 'app-status-bar',
  imports: [],
  templateUrl: './status-bar.html',
  styleUrl: './status-bar.css',
  host:{
    class:'h-7 shrink-0 flex items-center px-4 border-t border-line bg-panel text-xs text-muted'
  }
})
export class StatusBar {}
