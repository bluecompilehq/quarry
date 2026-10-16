import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TopBar } from './layout/top-bar/top-bar';
import { ActivityRail } from './layout/activity-rail/activity-rail';
import { Explorer } from './layout/explorer/explorer';
import { StatusBar } from './layout/status-bar/status-bar';
import { QueryEditor } from './features/query/query-editor/query-editor';
import { ResultsGrid } from './features/query/results-grid/results-grid';

@Component({
  selector: 'app-root',
  imports: [TopBar,ActivityRail,Explorer,StatusBar,QueryEditor,ResultsGrid],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
 
}
