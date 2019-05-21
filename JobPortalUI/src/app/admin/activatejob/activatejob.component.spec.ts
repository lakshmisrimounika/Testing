import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivatejobComponent } from './activatejob.component';

describe('ActivatejobComponent', () => {
  let component: ActivatejobComponent;
  let fixture: ComponentFixture<ActivatejobComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActivatejobComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivatejobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
