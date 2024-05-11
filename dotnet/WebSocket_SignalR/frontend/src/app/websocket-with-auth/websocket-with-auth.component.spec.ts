import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WebsocketWithAuthComponent } from './websocket-with-auth.component';

describe('WebsocketWithAuthComponent', () => {
  let component: WebsocketWithAuthComponent;
  let fixture: ComponentFixture<WebsocketWithAuthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WebsocketWithAuthComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WebsocketWithAuthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
