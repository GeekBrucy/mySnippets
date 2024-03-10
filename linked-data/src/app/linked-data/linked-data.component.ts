import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-linked-data',
  templateUrl: './linked-data.component.html',
  styleUrl: './linked-data.component.scss'
})
export class LinkedDataComponent implements OnInit {
  public data = [
    {
      current: 1,
      next: 2,
      desc: "Node 1"
    },
    {
      current: 3,
      next: 4,
      desc: "Node 3"
    },
    {
      current: 5,
      next: null,
      desc: "Node 5"
    },
    {
      current: 2,
      next: 3,
      desc: "Node 2"
    },
    {
      current: 4,
      next: 5,
      desc: "Node 4"
    }
  ];
  public sortedData: any[] = [];
  constructor() {
  }

  ngOnInit(): void {
    this.sortedData = this.data;
  }

}
