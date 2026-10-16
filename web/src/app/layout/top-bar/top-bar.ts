import { Component, signal } from '@angular/core';
import { LucideAngularModule, Plus, Search } from 'lucide-angular';

interface QueryTab{
  id:number,
  title:string;
}

@Component({
  selector: 'app-top-bar',
  imports: [LucideAngularModule],
  templateUrl: './top-bar.html',
  styleUrl: './top-bar.css',
  host: {
    class: 'h-13 shrink-0 flex items-center px-4 border-b border-line bg-panel'
  }
})


export class TopBar {

  protected readonly PlusIcon = Plus;
  protected readonly SearchIcon = Search;

  protected readonly tabs = signal<QueryTab[]>([
    {id:1 ,title:'top-customers-sql'},
   { id: 2, title: 'orders-by-month.sql' }
  ])
  protected readonly activeTabId =signal(1);

  protected  AddTab():void{
    const id =Math.max(0,...this.tabs().map(t=>t.id)) +1;
    this.tabs.update(tabs=> [...tabs, {id,title:`query-${id}.sql`}]);
    this.activeTabId.set(id);
  }
}
