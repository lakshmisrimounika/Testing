import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivaterecruitersComponent } from './activaterecruiters.component';

describe('ActivaterecruitersComponent', () => {
  let component: ActivaterecruitersComponent;
  let fixture: ComponentFixture<ActivaterecruitersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActivaterecruitersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivaterecruitersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
