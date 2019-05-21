import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewalljobComponent } from './viewalljob.component';

describe('ViewalljobComponent', () => {
  let component: ViewalljobComponent;
  let fixture: ComponentFixture<ViewalljobComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewalljobComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewalljobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
