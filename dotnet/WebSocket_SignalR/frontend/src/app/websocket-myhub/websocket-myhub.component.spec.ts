import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WebsocketMyhubComponent } from './websocket-myhub.component';

describe('WebsocketMyhubComponent', () => {
  let component: WebsocketMyhubComponent;
  let fixture: ComponentFixture<WebsocketMyhubComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WebsocketMyhubComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WebsocketMyhubComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
