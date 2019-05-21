import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListingjobComponent } from './listingjob.component';

describe('ListingjobComponent', () => {
  let component: ListingjobComponent;
  let fixture: ComponentFixture<ListingjobComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListingjobComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListingjobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
