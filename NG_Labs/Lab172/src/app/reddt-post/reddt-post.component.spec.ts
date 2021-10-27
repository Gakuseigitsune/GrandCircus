import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReddtPostComponent } from './reddt-post.component';

describe('ReddtPostComponent', () => {
  let component: ReddtPostComponent;
  let fixture: ComponentFixture<ReddtPostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReddtPostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReddtPostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
